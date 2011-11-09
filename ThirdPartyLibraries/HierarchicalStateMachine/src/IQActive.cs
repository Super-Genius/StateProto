// -----------------------------------------------------------------------------
//                            qf4net Library
//
// Port of Samek's Quantum Framework to C#. The implementation takes the liberty
// to depart from Miro Samek's code where the specifics of desktop systems 
// (compared to embedded systems) seem to warrant a different approach.
// Please see accompanying documentation for details.
// 
// Reference:
// Practical Statecharts in C/C++; Quantum Programming for Embedded Systems
// Author: Miro Samek, Ph.D.
// http://www.quantum-leaps.com/book.htm
//
// -----------------------------------------------------------------------------
//
// Copyright (C) 2003-2004, The qf4net Team
// All rights reserved
// Lead: Rainer Hessmer, Ph.D. (rainer@hessmer.org)
// 
//
//   Redistribution and use in source and binary forms, with or without
//   modification, are permitted provided that the following conditions
//   are met:
//
//     - Redistributions of source code must retain the above copyright
//        notice, this list of conditions and the following disclaimer. 
//
//     - Neither the name of the qf4net-Team, nor the names of its contributors
//        may be used to endorse or promote products derived from this
//        software without specific prior written permission. 
//
//   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
//   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
//   THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
//   INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//   (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//   SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
//   HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
//   STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//   ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
//   OF THE POSSIBILITY OF SUCH DAMAGE.
// -----------------------------------------------------------------------------


using System;

namespace qf4net
{
	/// <summary>
	/// Interface that Active Objects implement.
	/// </summary>
	public interface IQActive
	{
		/// <summary>
		/// Start the <see cref="IQActive"/> object's thread of execution. The caller needs to assign a unique
		/// priority to every <see cref="IQActive"/> object in the system. 
		/// </summary>
		/// <param name="priority">The priority associated with this <see cref="IQActive"/> object.</param>
		// TODO: Are there more flexible ways to handle the priority? Does it really need to be unique in the whole process / system?
		void Start(int priority);

		/// <summary>
		/// The priority associated with this <see cref="IQActive"/> object. Once the <see cref="IQActive"/> object
		/// is started the priority is non-negative. For an <see cref="IQActive"/> object that has not yet been started
		/// the value -1 is returned as the priority.
		/// </summary>
		int Priority { get; }

		/// <summary>
		/// Post the <see paramref="qEvent"/> directly to the <see cref="IQActive"/> object's event queue
		/// using the FIFO (First In First Out) policy. 
		/// </summary>
		/// <param name="qEvent"></param>
		void PostFIFO(IQEvent qEvent);

		/// <summary>
		/// Post the <see paramref="qEvent"/> directly to the <see cref="IQActive"/> object's event queue
		/// using the LIFO (Last In First Out) policy. 
		/// </summary>
		/// <param name="qEvent"></param>
		void PostLIFO(IQEvent qEvent);

		/// <summary>
		/// Determines whether the state machine is in the state specified by <see paramref="inquiredState"/>.
		/// </summary>
		/// <param name="inquiredState">The state to check for.</param>
		/// <returns>
		/// <see langword="true"/> if the state machine is in the specified state; 
		/// <see langword="false"/> otherwise.
		/// </returns>
		/// <remarks>
		/// If the currently active state of a hierarchical state machine is s then it is in the 
		/// state s AND all its parent states.
		/// </remarks>
		bool IsInState(QState inquiredState);

		/// <summary>
		/// Returns the name of the (deepest) state that the state machine is currently in.
		/// </summary>
		string CurrentStateName { get; }
	}
}
