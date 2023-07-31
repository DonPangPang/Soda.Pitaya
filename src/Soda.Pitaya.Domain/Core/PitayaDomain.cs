using System.Runtime.Loader;

namespace Soda.Pitaya.Domain.Core
{
    public partial class PitayaDomain : AssemblyLoadContext, IDisposable, IAsyncDisposable
    {
        private const string DEFAULT = "DEFAULT";

        public PitayaDomain() : base(DEFAULT)
        {
        }

        public PitayaDomain(string key) : base(key, true)
        {
            if (key.Equals(DEFAULT, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("not create default domain");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Run(() =>
            {
                GC.SuppressFinalize(this);
            });
        }
    }
}