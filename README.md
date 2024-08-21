# Budget Calculator

## Project Overview

This is a Budget Calculator web application designed to calculate the ad budget. Users can input the total budget, agency fee percentage, third-party tool fee percentage, fixed costs, and other ad budgets. The system will calculate and display the maximum budget for a specific ad that fits within the total budget.

## Demo

<img width="1499" alt="image" src="https://github.com/user-attachments/assets/0b5d42c3-074c-49e4-a261-ce31e95182b2">



### Usage Instructions
1. **Ad Budget X1:** Enter the budget amount for the first ad. Indicate if a third-party tool is used by checking the corresponding checkbox.
2. **Ad Budget X2:** Enter the budget amount for the second ad. Indicate if a third-party tool is used by checking the corresponding checkbox.
3. **Ad Budget X3:** Enter the budget amount for the third ad. Indicate if a third-party tool is used by checking the corresponding checkbox.
4. **Ad Budget - Target Xi:** This budget will be calculated based on the results. Use the checkbox to indicate if a third-party tool is used.
5. **Total Campaign Budget (Z):** Enter the total budget available for the entire campaign.
6. **Agency Fee Percentage (Y1):** Enter the agency fee percentage (e.g., 0.10 for 10%).
7. **Third-Party Tool Fee Percentage (Y2):** Enter the third-party tool fee percentage (e.g., 0.05 for 5%).
8. **Fixed Cost for Agency Hours (HOURS):** Enter the fixed cost for agency hours.



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
