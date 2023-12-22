from ultralytics import YOLO

model = YOLO("Best_Model.pt")

results = model.predict(source="0", show=True, conf=0.5, verbose=False)
print(model.predictor.predict_cli(source="0"))
# # Extract relevant information from the results
# detection_info = results.xyxy[0].numpy().tolist() if results.xyxy[0] else []

# # Print information for each detection
# for detection in detection_info:
#     class_name, score, (x, y, w, h) = detection[5], detection[4], detection[0:4]
#     print(class_name+"ssssssssssssssssssssssssssssssssssssssssssssssssss")
#     if model.names[int(class_name)] == 'Numeric-2':
#         # Print detection information
#         print(f'Class: {model.names[int(class_name)]}, Score: {score:.2f}, Bounding Box: {int(x)}, {int(y)}, {int(w)}, {int(h)}')
