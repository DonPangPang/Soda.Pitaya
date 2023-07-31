using System.Diagnostics;
using System.Reflection;

namespace Soda.Pitaya.Domain.Core;

public partial class PitayaDomain
{
    protected override Assembly? Load(AssemblyName assemblyName)
    {
#if DEBUG
        Debug.WriteLine($"[解析]程序集: {assemblyName.Name}; 全名: {assemblyName.FullName}");
#else
        Trace.WriteLine($"[解析]程序集: {assemblyName.Name}; 全名: {assemblyName.FullName}");
#endif

        return base.Load(assemblyName);
    }
}