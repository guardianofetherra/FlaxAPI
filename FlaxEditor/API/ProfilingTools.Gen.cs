////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEditor.Profiling
{
	/// <summary>
	/// Profiler tools for editor. Allows to gather profiling data and events from the engine.
	/// </summary>
	public partial class ProfilingTools
	{
		/// <summary>
		/// Gets the collected main stats by the profiler from local or remote session.
		/// </summary>
		[UnmanagedCall]
		public static MainStats Stats
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { MainStats resultAsRef; Internal_GetStats(out resultAsRef); return resultAsRef; }
#endif
		}

		/// <summary>
		/// Gets the collected CPU events by the profiler from local or remote session.
		/// </summary>
		/// <param name="size">The result amount of value events in the returned array.</param>
		/// <param name="buffer">The input buffer to fill. Will reuse it or allocate new one and return it. May be null.</param>
		/// <returns>Buffer with input events. Events count is equal to returned size parameter value. It may be the input buffer or allocated one.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static ThreadStats[] GetEventsCPU() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_GetEventsCPU();
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetStats(out MainStats resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern ThreadStats[] Internal_GetEventsCPU();
#endif
#endregion
	}
}

