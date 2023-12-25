from ultralytics import YOLO
import cv2

model = YOLO("Best_Model.pt")

results = model.predict(source="0", show=True, conf=0.5, verbose=True)
# print(model.predictor.predict_cli(source="0"))
# cap = cv2.VideoCapture(0)
# while cap.isOpened():
#     # Read a frame from the video
#     success, frame = cap.read()
#     frame = cv2.resize(frame, (640, 640))
#     if success:
#         # Run YOLOv8 tracking on the frame, persisting tracks between frames
#         results = model.track(frame, conf=0.7, iou=0.9, persist=True)

#         # Check if there are any detections
#         if results and results[0]['xyxy'] is not None and len(results[0]['xyxy']) > 0:
#             boxes = results[0]['xyxy'].cpu()
#             classses = results[0]['xyxy'].cls.int().cpu().tolist()
#             track_ids = results[0]['xyxy'].id.int().cpu().tolist()

#             # Rest of your code...
#             for box, track_id, classs in zip(boxes, track_ids, classses):
#                 if 29 in classses:
#                     position = classses.index(29)
#                     x1, y1, not1, not2 = box.cpu().numpy().astype(int)
#                     point1 = (int(x1), int(y1))
#                     # Continue with the rest of your code...
