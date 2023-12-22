from ultralytics import YOLO
from ultralytics.models.yolo.detect.predict import DetectionPredictor
#elly 3awz y5of el camera y7ot paramerter dh t7t "show=True"    
model=YOLO("Best_Model.pt")
results=model.predict(source="0",show=True,conf=0.5)
print(results)