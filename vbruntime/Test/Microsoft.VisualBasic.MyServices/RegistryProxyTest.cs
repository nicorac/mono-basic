// RegistryProxyTest.cs - NUnit Test Cases for Microsoft.VisualBasic.MyServices.RegistryProxy
//
// Rolf Bjarne Kvinge  (RKvinge@novell.com)
//
// 
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
#if NET_2_0
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.VisualBasic.MyServices;

namespace MonoTests.Microsoft_VisualBasic.MyServices
{
	[TestFixture]
	public class RegistryProxyTest
	{
		[Test]
		public void TestGetValue ()
		{
			Microsoft.VisualBasic.MyServices.RegistryProxy registry = getProxy ();
			object value = registry.GetValue ("HKEY_CLASSES_ROOT", ".txt", "a");
			Assert.AreEqual ("a", value, "#01");
		}
		
		[Test]
		public void TestSetValue ()
		{
			Microsoft.VisualBasic.MyServices.RegistryProxy registry = getProxy ();
			string name = ".someweirdthing";
			string keyname = "HKEY_CLASSES_ROOT\\" + name;
			string valuename = ".name";
			registry.SetValue (keyname, valuename, "a");
			object value = registry.GetValue (keyname, valuename, "b");
			Assert.AreEqual ("a", value, "#01");
			registry.SetValue (keyname, valuename, "c");
			value = registry.GetValue (keyname, valuename, "c");
			Assert.AreEqual ("c", value, "#02");
			
			registry.ClassesRoot.DeleteSubKey(name);
		}
		
		[Test]
		public void TestSetValue2 ()
		{
			Microsoft.VisualBasic.MyServices.RegistryProxy registry = getProxy ();
			string name = ".someweirdthing";
			string keyname = "HKEY_CLASSES_ROOT\\" + name;
			string valuename = ".name";
			registry.SetValue (keyname, valuename, 1);
			object value = registry.GetValue (keyname, valuename, 2);
			Assert.AreEqual (1, value, "#01");
			registry.SetValue (keyname, valuename, 3, Microsoft.Win32.RegistryValueKind.DWord);
			value = registry.GetValue (keyname, valuename, 3);
			Assert.AreEqual (3, value, "#02");
			
			registry.ClassesRoot.DeleteSubKey(name);
		}
		
		[Test]
		public void TestGlobalKeys ()
		{
			Microsoft.Win32.RegistryKey classes, currentconfig, currentuser, dyndata, localmachine, perfdata, users;
			Microsoft.VisualBasic.MyServices.RegistryProxy registry = getProxy ();
			
			classes = registry.ClassesRoot;
			Assert.AreEqual ("HKEY_CLASSES_ROOT", classes.Name, "ClassesRoot");
			
			currentconfig = registry.CurrentConfig;
			Assert.AreEqual ("HKEY_CURRENT_CONFIG", currentconfig.Name, "CurrentConfig");
			
			currentuser = registry.CurrentUser;
			Assert.AreEqual ("HKEY_CURRENT_USER", currentuser.Name, "CurrentUser");
			
			dyndata = registry.DynData;
			Assert.AreEqual ("HKEY_DYN_DATA", dyndata.Name, "DynData");
			
			localmachine = registry.LocalMachine;
			Assert.AreEqual ("HKEY_LOCAL_MACHINE", localmachine.Name, "LocalMachine");
			
			perfdata = registry.PerformanceData;
			Assert.AreEqual ("HKEY_PERFORMANCE_DATA", perfdata.Name, "PerformanceData");
			
			users = registry.Users;
			Assert.AreEqual ("HKEY_USERS", users.Name, "Users");
			
		}
		
		Microsoft.VisualBasic.MyServices.RegistryProxy getProxy ()
		{
			return (new Microsoft.VisualBasic.Devices.Computer()).Registry;
		}
	}
}
#endif