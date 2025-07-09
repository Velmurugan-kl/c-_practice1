# Contact Manager

This is a console based application developed using c#. It allows you to manage the contacts. The application is designed for ease of use and provides basic functionalities for managing contact information.

## Features

- **Contact Information Management:** Add, edit, and delete contacts with details such as name, phone number, email address, and notes.
- **Contact List Display:** View a list of all contacts with their names for easy identification.
- **Search Functionality:** Search for contacts by name or other details and display matching results.
- **Console-Based User Interface:** Interact with the application using a menu-driven console interface.
- **Error Handling:** Graceful handling of input errors

## Usage Instruction

- Initially you will be greeted with the **Main Menu** which is used to navigate between the [View, Search, Add, Update, Delete] options
- The view and Search function works only when there is atleast one data in the contacts list
- You search/Update/Delete the user either by entering the Phone Number or Name

## Limitations

- **In-Memory Storage:** Contact data is stored in memory and will be lost when the application is closed.
- **No Data Persistence:** This version does not save data to files or databases.

## Additional Notes

- created basic class with no proper access modifiers but will implement it properly in the next version.
- currently working on the sorting the contacts by ascending order and it requires only minor code refactoring.

## Work flow

- In the project the Program.cs is the main code that is executed.
- The Functionalities class has all the methods to handle the contact information management.
- The Services class act as the class to have the repeateadly called methods by the functionalities to improve code readability and contains the methods to verify number, name and mail.
- The Utilities clss is for the methods that validates the given input.
