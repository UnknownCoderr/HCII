from ultralytics import YOLO
import cv2
import numpy as np
from collections import Counter

model = YOLO("Best_Model.pt")
camera = cv2.VideoCapture(0)
num_frames = 20
captured_frames = []

for _ in range(num_frames):
    ret, frame = camera.read()

    if not ret:
        print("Failed to grab frame")
        break

    cv2.imshow("test", frame)
    captured_frames.append(frame)
camera.release()

# Predict using the captured frames
predicted_classes = []
results = model(captured_frames)  # list of Results objects -> perform inference using the model
names = model.names

for r in results:
    for c in r.boxes.cls:
        predicted_classes.append(names[int(c)])

# Find the most frequent predicted class
most_common_class = Counter(predicted_classes).most_common(1)
final_predicted_class = most_common_class[0][0]

print("Final Predicted Class:", final_predicted_class)