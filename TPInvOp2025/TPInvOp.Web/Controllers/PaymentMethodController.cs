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
        public IActionResult Create(PaymentMethodEditVm paymentMethodEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paymentMethodEditVm);
            }

            var paymentDto = _mapper.Map<PaymentMethodEditDto>(paymentMethodEditVm);

            try
            {
                if (_paymentMethodService.Add(paymentDto, out var errors))
                {
                    TempData["Success"] = "Register successfully added.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(paymentMethodEditVm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "⚠ Ocurrió un error inesperado: " + ex.Message);
                return View(paymentMethodEditVm);
            }
        }
    }
}
