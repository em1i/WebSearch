# WebSearch

To run the application:
1. Download the WebSearchApp
2. Open Terminal in the WebSearchApp directory
3. dotnet run
4. Click the "Now listening on:" url. It's probably "http://localhost:5001"


Sample search words to test:
To test stemming use: 
- "engineer" will also return results containing "engineering"
- "educate" will also return results containing "education"
- "lecture" will also return results containing "lecturer"

To test misspellings use:
- "schhook" will return results containing "school"
- "mannager" will return results containing "manager"


Test data created using the code in put_profile6.txt and test_data.py and stored on Elastic Cloud.
Contains 10000 records.
Acess available until the end of April.