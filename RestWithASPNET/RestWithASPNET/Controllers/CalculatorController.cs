using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    

    private readonly ILogger<CalculatorController> _logger;

    
    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }
    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber){
           //checking if params are valid numbers
        if(isNumeric(secondNumber) && isNumeric(firstNumber)){
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(division.ToString());
        }


        return BadRequest("Invalid Input");
    }
    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {    

        //checking if params are valid numbers
        if(isNumeric(secondNumber) && isNumeric(firstNumber)){
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }


        return BadRequest("Invalid Input");
    }
      [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiplication(string firstNumber, string secondNumber)
    {    

        //checking if params are valid numbers
        if(isNumeric(secondNumber) && isNumeric(firstNumber)){
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplication.ToString());
        }


        return BadRequest("Invalid Input");
    }

    //!SUBTRACTION
       [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtraction(string firstNumber, string secondNumber)
    {    

        //checking if params are valid numbers
        if(isNumeric(secondNumber) && isNumeric(firstNumber)){
            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }


        return BadRequest("Invalid Input");
    }


    [HttpGet("squareroot/{firstNumber}")]
    public IActionResult GetSquareRoot(string firstNumber)
    {    

        //checking if params are valid numbers
        if(isNumeric(firstNumber)){
            var sqrt = Math.Sqrt((ConvertToDouble(firstNumber)));
            return Ok(sqrt.ToString());
        }


        return BadRequest("Invalid Input");
    }
       [HttpGet("average/{firstNumber}/{secondNumber}")]
    public IActionResult GetAverage(string firstNumber, string secondNumber)
    {    

        //checking if params are valid numbers
        if(isNumeric(secondNumber) && isNumeric(firstNumber)){
            var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(average.ToString());
        }


        return BadRequest("Invalid Input");
    }
    
    private bool isNumeric(string stringNumber){
        double number;
        //TryParse methods takes 4 arguments(string, numberStyle, numberFormat, variable to store)
        bool isNumber = 
        double.TryParse
        (stringNumber, 
        System.Globalization.NumberStyles.Any, 
        System.Globalization.NumberFormatInfo.InvariantInfo, 
        out number);


        return isNumber;
       
    }
    private decimal ConvertToDecimal(string number){
       
       decimal decimalValue;
       if (decimal.TryParse(number,out decimalValue)){
            return decimalValue;
       }
       
       return 0;

    }
        private double ConvertToDouble(string number){
       
       double doubleValue;
       if (double.TryParse(number,out doubleValue)){
            return doubleValue;
       }
       
       return 0;

    }
}
