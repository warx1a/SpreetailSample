# App Overview

This app will manage a dictionary that is capable of storing multiple values for a given key. This uses a Dictionary<string, List<string>> in the backend to manage this.

This app will run as a console application.

# Commands
<br/>
Some available commands are listed below:

ADD [key] [value]: Adds a given key/value combination to the dictionary. If the key already exists, the value will be appended to the existing values.<br/>
REMOVE [key] [value]: Removes a given key/value combination from the dictionary. If the removed value is the last remaining value for the key, the key will also be removed from the dictionary.<br/>
REMOVEALL [key]: Removes all values under a given key. Will throw an error message if the key to remove is not in the dictionary. This function will also remove the associated key from the dictionary.<br/>
CLEAR: Removes all key/value combination in the dictionary.<br/>
KEYEXISTS [key]: Returns true if the given key is found in the dictionary. Returns false otherwise.<br/>
MEMBEREXISTS [key] [value]: Returns true if the value to find is contained under the existing key/value combination. Returns false otherwise.<br/>
KEYS: Returns all keys in the dictionary. Will return an empty set if no keys available.<br/>
MEMBERS [key]: Returns all values associated with a key in the dictionary. Returns an empty set if none are available. Returns an error if the key doesnt exist.<br/>
ALLMEMBERS: Returns all values stored in the dictionary.<br/>
ITEMS: Returns all key/value combinations in the dictionary.<br/>

# Build

`dotnet build`

# Run

`dotnet run`

