using FluentValidation;
using HotelProject.WUI.Dtos.GuestDto;

namespace HotelProject.WUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {

        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SoyAd alanı boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 2 karakter veri girişi yapınız");
            RuleFor(x => x.SurName).MaximumLength(30).WithMessage("Lütfen fazla az 3 karakter veri girişi yapınız");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen en fazla 3 karakter veri girişi yapınız");
        }
    }
}
