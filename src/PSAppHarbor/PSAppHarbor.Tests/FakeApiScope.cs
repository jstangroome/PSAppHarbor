using System;

namespace PSAppHarbor.Tests
{
    class FakeApiScope : IDisposable
    {
        private readonly Func<IAppHarborApi> _originalApi;

        public FakeApiScope()
        {
            _originalApi = ApiProvider.Instance.GetApi;
            Api = new FakeAppHarborApi();
            ApiProvider.Instance.GetApi = () => Api;
        }

        public FakeAppHarborApi Api { get; set; }

        public void Dispose()
        {
            ApiProvider.Instance.GetApi = _originalApi;
        }
    }
}