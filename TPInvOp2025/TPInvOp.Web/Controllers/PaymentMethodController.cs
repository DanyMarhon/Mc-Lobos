using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.PaymentMethod;

namespace TPInvOp.Web.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;

        public PaymentMethodController(IPaymentMethodService paymentMethodService, IMapper mapper)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var paymentDto = _paymentMethodService.GetAll();
            var paymentVm = _mapper.Map<List<PaymentMethodListVm>>(paymentDto);
            return View(paymentVm);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentMethodEditVm paymentMethodVm)
        {
            if (ModelState.IsValid)
            {
                PaymentMethodEditDto paymentMethodDto = _mapper.Map<PaymentMethodEditDto>(paymentMethodVm);
                try
                {
                    if (_paymentMethodService.Save(paymentMethodDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Added";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, errors.First());
                    }
                    return View(paymentMethodVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                }

            }
            return View(paymentMethodVm);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                PaymentMethodEditDto? paymentMethodDto = _paymentMethodService.PaymentMethodById(id.Value);
                if (paymentMethodDto is null)
                {
                    return NotFound($"Payment Method With Id {id} Not Found!!");
                }
                PaymentMethodEditVm paymentMethodVm = _mapper.Map<PaymentMethodEditVm>(paymentMethodDto);
                return View(paymentMethodVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a payment method";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaymentMethodEditVm paymentMethodVm)
        {
            if (ModelState.IsValid)
            {
                PaymentMethodEditDto paymentMethodDto = _mapper.Map<PaymentMethodEditDto>(paymentMethodVm);
                try
                {
                    if (_paymentMethodService.Save(paymentMethodDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Updated";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, errors.First());
                    }
                    return View(paymentMethodVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                }

            }
            return View(paymentMethodVm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                PaymentMethodEditDto? paymentMethodDto = _paymentMethodService.PaymentMethodById(id.Value);
                if (paymentMethodDto is null)
                {
                    return NotFound($"Payment Method With Id {id} Not Found!!");
                }
                PaymentMethodEditVm paymentMethodVm = _mapper.Map<PaymentMethodEditVm>(paymentMethodDto);
                return View(paymentMethodVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a payment method";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                PaymentMethodEditDto? paymentMethodDto = _paymentMethodService.PaymentMethodById(id.Value);
                if (paymentMethodDto is null)
                {
                    return NotFound($"Payment Method With Id {id} Not Found!!");
                }
                if (_paymentMethodService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Payment Method Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    PaymentMethodEditVm paymentMethodVm = _mapper.Map<PaymentMethodEditVm>(paymentMethodDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(paymentMethodVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a payment method";
                return RedirectToAction("Index");
            }
        }
    }
}
