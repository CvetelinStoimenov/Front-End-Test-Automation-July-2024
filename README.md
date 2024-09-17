# QA Automation Project - Foody Application

## Overview

This project involves the development of automated UI tests for the Foody web application. The focus is on verifying core CRUD functionalities and user interactions to ensure the application's stability and performance. The key areas of testing include food item creation, editing, deletion, and search features.

## Key Features

- **Automated Login Process:** Implemented automated tests for logging into the Foody application.
- **Food Item Creation:** Validated the functionality of adding food items with both valid and invalid data.
- **Editing and Deletion:** Developed test cases for editing and deleting the last added food item to ensure correct updates and removal.
- **Search Functionality:** Tested the food search functionality by comparing the search results with the expected data.
- **Element Identification:** Utilized XPath and CSS Selectors for precise element identification and assertions to verify UI changes and data integrity.

## Technologies & Tools

- **Selenium:** For browser automation and interaction with the web application.
- **ChromeDriver:** To control the Chrome browser for testing.
- **WebDriver:** Selenium's interface for interacting with web elements.
- **Actions:** For simulating complex user interactions.
- **NUnit:** Testing framework for writing and running tests.
- **C#:** Programming language used for writing test scripts.
- **XPath & CSS Selectors:** For locating web elements in the application.

## Outcome

The automated tests have significantly enhanced test coverage for critical user flows within the Foody application. This improvement has led to quicker defect identification and a reduction in manual testing efforts, ensuring a more reliable and efficient testing process.

## Getting Started

To set up and run the tests locally, follow these steps:

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/yourusername/foody-automation-project.git
   cd foody-automation-project
   ```

2. **Install Dependencies: Ensure you have .NET SDK installed. Restore the necessary packages:**
   ```sh
   dotnet restore
   ```
3. **Build the Project:**
   ```sh
   dotnet build
   ```
4. **Run the Tests:**
   ```sh
   dotnet test
   ```

   ## Contributing

Contributions to this project are welcome. If you have suggestions or improvements, please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
