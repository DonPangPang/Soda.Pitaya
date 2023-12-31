﻿using System.Reflection;
using System.Runtime.Loader;

namespace Soda.Pitaya.Domain.Core;

public partial class PitayaDomain
{
    private Assembly? DefaultResolving(AssemblyLoadContext arg1, AssemblyName arg2)
    {
        return Load(arg2);
    }

    private IntPtr DefaultResolvingUnmanagedDll(Assembly arg1, string arg2)
    {
        return LoadUnmanagedDll(arg2);
    }

    protected event Action<Assembly, string>? LoadAssemblyReferencesWithPath = null;
    private event Action<Assembly, Stream>? LodaAssemblyReferencesWithStream = null;
}