import requests
response = requests.get(" https://google.com")

print("Response code:", response.status_code)
print("Response formatted as text:",response.text)
print("Response formatted in bytes:",response.content)
print("Response Headers:",response.headers)