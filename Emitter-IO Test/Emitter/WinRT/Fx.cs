/*
Copyright (c) 2016 Roman Atachiants
Copyright (c) 2013, 2014 Paolo Patierno

All rights reserved. This program and the accompanying materials
are made available under the terms of the Eclipse Public License v1.0
and Eclipse Distribution License v1.0 which accompany this distribution.

The Eclipse Public License:  http://www.eclipse.org/legal/epl-v10.html
The Eclipse Distribution License: http://www.eclipse.org/org/documents/edl-v10.php.

Contributors:
   Paolo Patierno - initial API and implementation and/or initial documentation
   Roman Atachiants - integrating with emitter.io
*/

using System.Threading.Tasks;

namespace Emitter
{
    /// <summary>
    /// Support methods fos specific framework
    /// </summary>
    public class Fx
    {
        public delegate void ThreadStart();

        public static void StartThread(ThreadStart threadStart)
        {
            Task.Factory.StartNew(o => ((ThreadStart)o)(), threadStart);
        }

        public static void SleepThread(int millisecondsTimeout)
        {
            Task.Delay(millisecondsTimeout).RunSynchronously();
        }
    }
}