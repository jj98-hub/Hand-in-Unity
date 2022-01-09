import json
import cv2
import mediapipe as mp
import time 
import math
import redis



# initialize for opencv and mediapipe
cap = cv2.VideoCapture(0)
mpHands = mp.solutions.hands
hands = mpHands.Hands(max_num_hands=1,
    min_detection_confidence=0.7)
mpDraw = mp.solutions.drawing_utils

#tip of finger

thumb = 4
index = 8
middle = 12
ring = 16
pinky = 20

#send initiail position to unity
handpos = [0, 0, 0] 

#initialize redis
rediscon = redis.Redis(host="127.0.0.1",port=6379)
redischannel = "Tracking"
#main function

while True:
    ret, frame = cap.read()
    frame = cv2.flip(frame,1)
    HandData = {}
    imgRGB = cv2.cvtColor(frame,cv2.COLOR_BGR2RGB)
    result = hands.process(imgRGB)
    if result.multi_hand_landmarks:
        for handLms in result.multi_hand_landmarks:
            for id, lm in enumerate(handLms.landmark):
                h,w,c = frame.shape
                cx,cy,cz =lm.x*w,-1*lm.y*h,lm.z*w
                handpos = [lm.x,lm.y,lm.z]
                HandData["id"+str(id)] = [cx,cy,cz]
        data_to_send = json.dumps(HandData)
        
        rediscon.publish(redischannel,data_to_send)
        print(data_to_send)
        time.sleep(0.1)

