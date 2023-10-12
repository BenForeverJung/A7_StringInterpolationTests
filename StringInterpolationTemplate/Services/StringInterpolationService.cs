using System;
using System.Text;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        Console.WriteLine(answer);

        return answer;
    }

    //2.2019.01.22
    public string Number02()
    {
        var date = _date.Now.ToString("yyyy.MM.dd");
        var answer = $"{date}";
        Console.WriteLine(answer);

        return answer;
    }

    //3.day 22 of january, 2019
    public string Number03()
    {
        var date = _date.Now.ToString("'Day' dd 'of' MMMM, yyyy");
        var answer = $"{date}";
        Console.WriteLine(answer);

        return answer;
    }

    //4.year: 2019, month: 01, day: 22
    public string Number04()
    {
        var date = _date.Now.ToString("'Year:' yyyy, 'Month:' MM, 'Day:' dd");
        var answer = $"{date}";
        Console.WriteLine(answer);

        return answer;
    }

    //5.tuesday(10 spaces total, right aligned)
    public string Number05()
    {
        var date = _date.Now.ToString("dddd");
        var answer = $"{date,10}";
        Console.WriteLine(answer);

        return answer;
    }

    //6.     11:01 pm tuesday(10 spaces total for each including the day - of - week, both right - aligned)
    public string Number06()
    {
        var date = _date.Now.ToString("hh:mm tt");
        var day = _date.Now.ToString("dddd");
        var answer = $"{date,10}{day,10}";
        Console.WriteLine(answer);

        return answer;
    }

    //7.h:11, m: 01, s: 27
    public string Number07()
    {
        var date = _date.Now.ToString("'h:'hh, 'm:'mm, 's:'ss");
        var answer = $"{date}";
        Console.WriteLine(answer);

        return answer;
    }

    //8.2019.01.22.11.01.27
    public string Number08()
    {
        var date = _date.Now.ToString("yyyy.MM.dd.hh.mm.ss");
        var answer = $"{date}";
        Console.WriteLine(answer);

        return answer;
    }


    //9. if you have pi output as currency
    public string Number09()
    {
        var pi = Math.PI;
        var answer = $"{pi:C2}";
        Console.WriteLine(answer);

        return answer;
    }

    //10. if you have pi
    //  output as right - aligned(10 spaces),
    //          number with 3 decimal places
    public string Number10()
    {
        var pi = Math.PI;
        var answer = $"{pi,10:N3}";
        Console.WriteLine(answer);

        return answer;
    }

    //11. You will write one additional item to
    //      output the year (2019) as a hexidecimal
    public string Number11()
    {
        var date = _date.Now.ToString("yyyy");
        byte[] bytes = Encoding.Default.GetBytes(date);
        var answer = Convert.ToHexString(bytes);

        Console.WriteLine(answer);

        return answer;

    }
}
