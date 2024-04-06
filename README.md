# SVG Drawing Application

This application allows you to draw and resize a rectangle using SVG. The dimensions of the rectangle are stored in a JSON file on the server and updated in real-time as you resize the rectangle.

## Technologies Used

- Angular for the frontend
- ASP.NET Core Web API for the backend

## Getting Started

### Prerequisites

- Node.js and npm
- .NET Core SDK
- Angular CLI

### Running the Application

1. Clone the repository.
2. Navigate to the Angular project directory and install the dependencies:

```bash
cd FrontEnd/rectangle-app
npm install
```
3. Start the Angular development server:

```bash
ng serve
```

4. In a new terminal, navigate to the ASP.NET Core project directory and run the API:

```bash
cd Backend/RectangleApi
dotnet run
```

5. Open your browser and navigate to http://localhost:4200


## Usage

Click and drag anywhere on the screen to draw and resize the rectangle. The dimensions of the rectangle are displayed below the rectangle and updated in real-time.

## License
[MIT](https://choosealicense.com/licenses/mit/)


This README.md provides a brief overview of the project, the technologies used, instructions for getting started, usage instructions, and the license.