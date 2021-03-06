﻿// *******************************************************************
//
//  Copyright (c) 2012-2016, Antmicro Ltd <antmicro.com>
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
// *******************************************************************
using System;
using System.Reflection.Emit;

namespace Antmicro.Migrant.Generators
{
    internal abstract class GenerationContextBase
    {
        public GenerationContextBase(ILGenerator generator, bool disableStamping, bool treatCollectionAsUserObject)
        {
            this.generator = generator;

            DisableStamping = disableStamping;
            TreatCollectionAsUserObject = treatCollectionAsUserObject;
        }

        public abstract GenerationContextBase WithGenerator(ILGenerator g);

        protected void CheckAndEmit(OpCode? argument)
        {
            if(!argument.HasValue)
            {
                throw new InvalidOperationException();
            }

            generator.Emit(argument.Value);
        }

        public bool DisableStamping { get; private set; }
        public bool TreatCollectionAsUserObject { get; private set; }
        public ILGenerator Generator { get { return generator; } }

        protected readonly ILGenerator generator;
    }
}

