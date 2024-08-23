# Budget Calculator

## Introduction

The system is designed to calculate the optimal advertising budget based on user inputs and various fees, using different algorithms to find the best budget configuration that meets the expected total budget.

## System Overview

The Budget Calculator system allows users to input the known budget for each ad, total campaign budget, agency fees, fees for ads created using third-party tools, and fixed costs for agency hours. It then calculates the specific ad budget using different algorithms, including Binary Search and Newton's Method. The primary features of the system are:

- Dynamic generation of ad budget input fields
- Provision of different algorithms to determine the best budget


## Demo

![image](https://github.com/user-attachments/assets/ed484117-2539-4143-b036-f7d7799e8e06)


## Design Approach
The system uses ASP.NET Core Razor Pages for the web framework, with Bootstrap for styling. The core logic consists of:

- **Frontend Form:** For user input of budgets and related parameters.
- **Backend Logic:** Handles form submission, calculates the budget using different algorithms, and displays the results.
- **Algorithm Implementations:** Provides algorithms for calculating the budget.


### Frontend Design

The frontend consists of a form where users can input:

- **Number of Ad Budgets:** The number of ad budget entries the user wants to input.
- **Amount for Each Ad Budget:** Dynamically generated fields where users can enter the amount for each ad budget and select whether a third-party tool is used.
- **Total Budget (Z):** The total campaign budget.
- **Agency Fee Percentage (Y1):** The percentage for the agency fee.
- **Third-Party Tool Fee Percentage (Y2):**  The percentage for the third-party tool fee.
- **Fixed Cost (HOURS):**  The fixed cost for agency hours.


### Model folder
- **AdBudget Model:** The AdBudget model represents each individual ad budget. Since the application allows users to manage multiple ad budgets, each with a specific amount and a flag indicating whether a third-party tool is used, this model encapsulates that data.
- **BudgetModel:** The BudgetModel aggregates all the data required for calculating the best budget. This includes a collection of AdBudget instances as well as additional parameters related to agency fees, third-party fees, and fixed costs.

### Services folder
- **BaseService.cs：** The BaseService class serves as a foundational class for implementing goal-seeking algorithms. It provides common functionalities that are shared across different goal-seeking methods.
- **IGoalSeek.cs ：** IGoalSeek is an interface that defines the contract for goal-seeking algorithms. It specifies the methods that any goal-seeking algorithm must implement.
- **NewtonMethod.cs：** The NewtonMethod class implements Newton's method, another algorithm for finding the optimal budget that meets the total campaign budget. Newton's method is an iterative numerical technique that uses derivatives to converge on a solution more quickly than simpler methods.
- **BinarySearch.cs：** The BinarySearch class implements a binary search algorithm to find the optimal budget that meets the total campaign budget. This algorithm works by iteratively narrowing down the range of possible values until it finds a value that satisfies the given constraints.



## Installation and Running

### Prerequisites

Ensure you have the following software installed on your machine:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)
- [Git](https://git-scm.com/) (optional)

### Clone the Project

Open a terminal and execute the following commands to clone the project:

```bash
git clone https://github.com/zoewang27/BudgetCalculator.git
cd BudgetCalculator
```

### Install Dependencies
Ensure you are in the project directory containing the BudgetCalculator.csproj file, then run the following command to restore the project's dependencies:
```bash
dotnet restore
```

### Run the Application
Execute the following command to start the application:
```bash
dotnet run
```

The application will start running on [http://localhost:5000] by default. If it doesn't, please use the URL provided in the console output.


### Access the Application
Open a browser and navigate to http://localhost:5000/budget to view the application.


## Testing
### Unit Tests
Unit tests are located in the Tests folder and are written using xUnit.

Run tests with:
```bash
dotnet test
```
