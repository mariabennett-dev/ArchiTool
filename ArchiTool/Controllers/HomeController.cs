using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArchiTool.ArchiToolLogic.Models;
using ArchiToolLogic.Repository;
using RotativaHQ.AspNetCore;

namespace ArchiTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly InMemoryUnitOfWork _ATRepo = new InMemoryUnitOfWork();

        public HomeController(InMemoryUnitOfWork atRepo)
        {
            _ATRepo = atRepo;
        }
        //Home view----------------------------------------------------------------------
        public IActionResult Index()
        {
            //Clear data for new user
            _ATRepo.Calculator.Clear();
            _ATRepo.HistoryRoofDimensions.ClearAll();
            _ATRepo.Calculator.ClearRoofCalculator();
            _ATRepo.ConversionCalcHistory.ClearAll();
            _ATRepo.Calculator.RoofCalcCount = 0;
            _ATRepo.Calculator.ConversionCalcCount = 0;
            return View();
        }

        //Roof calculator methods and views----------------------------------------------
        public IActionResult RoofCalculator()
        {
            return View(_ATRepo.Calculator.RD);
        }

        [HttpPost]
        public IActionResult Calculate(RoofDimensions roofDimensions)
        {
            _ATRepo.Calculator.RD = roofDimensions;
            if (_ATRepo.Calculator.CalculateDimensions() == 0)
            {
                if (_ATRepo.Calculator.CalculateRoof() == 0)
                {
                    // Save to history only if calculation is successful
                    _ATRepo.Calculator.RoofCalcCount++;
                    _ATRepo.Calculator.RD.Id = _ATRepo.Calculator.RoofCalcCount;
                    RoofDimensions copy = new RoofDimensions(_ATRepo.Calculator.RD);
                    _ATRepo.HistoryRoofDimensions.Add(copy);
                }
            }
            ModelState.Clear();
            
            return View("RoofCalculator", _ATRepo.Calculator.RD);
        }
        public IActionResult ClearRoofCalc()
        {
            _ATRepo.Calculator.ClearRoofCalculator();
            return View("RoofCalculator", _ATRepo.Calculator.RD);
        }

        public IActionResult ClearDimension(string dimension)
        {
            switch (dimension)
            {
                case "Slope":
                    _ATRepo.Calculator.ClearSlope();
                    break;
                case "Distance":
                    _ATRepo.Calculator.ClearDistance();
                    break;
                case "ICH":
                    _ATRepo.Calculator.ClearICH();
                    break;
                case "ECH":
                    _ATRepo.Calculator.ClearECH();
                    break;
            }
            return View("RoofCalculator", _ATRepo.Calculator.RD);
        }

        //Roof calculator history methods and views--------------------------------------
        public IActionResult RoofHistory()
        {
            return View(_ATRepo.HistoryRoofDimensions.GetAll());
        }

        public IActionResult ClearRoofHistory()
        {
            _ATRepo.HistoryRoofDimensions.ClearAll();
            return View("RoofHistory", _ATRepo.HistoryRoofDimensions.GetAll());
        }

        public ActionResult Export()
        {
            return new ViewAsPdf(_ATRepo.HistoryRoofDimensions.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _ATRepo.HistoryRoofDimensions.Delete(id);
            ModelState.Clear();
            return View("RoofHistory", _ATRepo.HistoryRoofDimensions.GetAll());
        }

        //Conversion calculator methods and views----------------------------------------
        public IActionResult ConversionCalculator()
        {
            return View(_ATRepo.Calculator);
        }

        [HttpPost]
        public IActionResult Save(Calculator calculator)
        {
            string answer = calculator.AnswerFormatSelected;
            _ATRepo.ConversionCalcHistory.Add(_ATRepo.Calculator.Save(answer));
            return View("ConversionCalculator", _ATRepo.Calculator);
        }

        public IActionResult CalcButton(string button)
        {
            try
            {
                switch (button)
                {
                    case "1":
                        _ATRepo.Calculator.NumberButton("1");
                        break;
                    case "2":
                        _ATRepo.Calculator.NumberButton("2");
                        break;
                    case "3":
                        _ATRepo.Calculator.NumberButton("3");
                        break;
                    case "4":
                        _ATRepo.Calculator.NumberButton("4");
                        break;
                    case "5":
                        _ATRepo.Calculator.NumberButton("5");
                        break;
                    case "6":
                        _ATRepo.Calculator.NumberButton("6");
                        break;
                    case "7":
                        _ATRepo.Calculator.NumberButton("7");
                        break;
                    case "8":
                        _ATRepo.Calculator.NumberButton("8");
                        break;
                    case "9":
                        _ATRepo.Calculator.NumberButton("9");
                        break;
                    case "0":
                        _ATRepo.Calculator.NumberButton("0");
                        break;
                    case ".":
                        _ATRepo.Calculator.Decimal();
                        break;
                    case "(-)":
                        _ATRepo.Calculator.Sign();
                        break;
                    case "+":
                        _ATRepo.Calculator.OperationButton("+");
                        break;
                    case "-":
                        _ATRepo.Calculator.OperationButton("-");
                        break;
                    case "x":
                        _ATRepo.Calculator.OperationButton("*");
                        break;
                    case "/":
                        _ATRepo.Calculator.OperationButton("/");
                        break;
                    case "mn":
                        _ATRepo.Calculator.MixedNumber();
                        break;
                    case "fr":
                        _ATRepo.Calculator.Fraction();
                        break;
                    case "in":
                        _ATRepo.Calculator.In();
                        break;
                    case "ft":
                        _ATRepo.Calculator.Ft();
                        break;
                    case "Clear":
                        _ATRepo.Calculator.Clear();
                        break;
                    case "=":
                        _ATRepo.Calculator.Equals();
                        break;
                    case "BckSp":
                        _ATRepo.Calculator.BackSpace();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _ATRepo.Calculator.ErrorMessage("Input Error: Clear to Continue");
            }
            return View("ConversionCalculator", _ATRepo.Calculator);
        }

        public IActionResult ConversionHistory()
        {
            return View(_ATRepo.ConversionCalcHistory.GetAll());
        }

        //Conversion calculator history methods and views--------------------------------
        public IActionResult ClearConversionCalcHistory()
        {
            _ATRepo.ConversionCalcHistory.ClearAll();
            return View("ConversionHistory", _ATRepo.ConversionCalcHistory.GetAll());
        }

        public ActionResult ExportConversionHistory()
        {
            return new ViewAsPdf(_ATRepo.ConversionCalcHistory.GetAll());
        }

        public IActionResult DeleteConversionHistory(int id)
        {
            _ATRepo.ConversionCalcHistory.Delete(id);
            ModelState.Clear();
            return View("ConversionHistory", _ATRepo.ConversionCalcHistory.GetAll());
        }
    }
}
