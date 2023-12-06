"# aspdotnet31-keycloak" 

get token:

curl --location 'localhost:8181/realms/hsf/protocol/openid-connect/token' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'grant_type=password' \
--data-urlencode 'client_id=client1' \
--data-urlencode 'username=hossein' \
--data-urlencode 'password=111111' \
--data-urlencode 'client_secret=IWKQpuleBS2HVVRix9TkjgF1I0Bun8BY'