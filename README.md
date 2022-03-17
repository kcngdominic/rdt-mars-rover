# Mars Rover
## Usage
1. **Normal**  
On your terminal, type:  
```dotnet run -- input.txt```  
where ``input.txt`` is the input according to the specification. Output would be printed on the console.

2. **Testing**  
On your terminal, type:  
```dotnet run -- test```  
All 4 preset testcase will be ran and the result compared with the expected output will be printed on console.

## Testcases
Testcases are located at:
```
.
├── testcase             # Testcases, in1.txt is supposed to give out1.txt
├── main.cs              # Manage argument input
├── Rover.cs             # Calcuate movement of one rover
├── RoverController.cs   # Combine calculation of multiple rovers
├── test.cs              # Run automated test
└── README.md
```