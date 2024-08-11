using CodeBase.Services.CurrencyAccountService;

namespace CodeBase.Services.ClickProvider
{
    public class ClickProvider : IClickProvider
    {
        private readonly ICurrencyAccountService _currencyAccount;

        public ClickProvider(ICurrencyAccountService currencyAccount)
        {
            _currencyAccount = currencyAccount;
        }

        public void OnClick()
        {
            _currencyAccount.ChangeGemValue(1);
        }
    }
}