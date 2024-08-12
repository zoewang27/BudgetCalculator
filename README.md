# Budget Calculator

## Project Overview

This is a Budget Calculator web application designed to calculate the ad budget. Users can input the total budget, agency fee percentage, third-party tool fee percentage, fixed costs, and other ad budgets. The system will calculate and display the maximum budget for a specific ad that fits within the total budget.

## Demo

<img width="957" alt="image" src="https://github.com/user-attachments/assets/1cc73caf-dc14-4224-91fc-4f72fed91219">

### Usage Instructions
1. **Total Campaign Budget (Z):** Enter the total budget available for the campaign.
2. **Agency Fee Percentage (Y1):** Enter the agency fee percentage (e.g., 0.10 for 10%).
3. **Third-Party Tool Fee Percentage (Y2):** Enter the third-party tool fee percentage (e.g., 0.05 for 5%).
4. **Fixed Cost for Agency Hours (HOURS):** Enter the fixed cost for agency hours.
5. **Budgets for Other Ads:** Enter the budgets for other ads, separated by commas (e.g., 1000,1500,2000).

### Online link: 


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

