import os
import shutil
import datetime
import time

c_drive = "C:/Users/vamsikrishna.akkala/Pictures"

threshold = 50

total, used, free = shutil.disk_usage(c_drive)

# utilization = used / total

#total, used, free = os.disk_usage("C:/")
disk_usage_percent = (used / total) * 100

if disk_usage_percent > threshold:
    now = datetime.datetime.now()
    delta = datetime.timedelta(days=1)
    one_month_ago = now - delta
    for root, dirs, files in os.walk(c_drive):
        for file in files:
            path = os.path.join(root, file)
            if os.stat(path).st_mtime < one_month_ago.timestamp():
                os.remove(path)
                #print(f"Disk usage: {disk_usage_percent:.2f}%")
                print(threshold)
                print(f"Deleting {path}")

                #time.sleep(60)
