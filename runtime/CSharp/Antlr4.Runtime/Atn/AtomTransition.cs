// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

/*
* Copyright (c) 2012 The ANTLR Project. All rights reserved.
* Use of this file is governed by the BSD-3-Clause license that
* can be found in the LICENSE.txt file in the project root.
*/
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
    /// <summary>TODO: make all transitions sets? no, should remove set edges</summary>
    public sealed class AtomTransition : Transition
    {
        /// <summary>The token type or character value; or, signifies special label.</summary>
        public readonly int label;

        public AtomTransition(ATNState target, int label)
            : base(target)
        {
            this.label = label;
        }

        public override Antlr4.Runtime.Atn.TransitionType TransitionType
        {
            get
            {
                return Antlr4.Runtime.Atn.TransitionType.Atom;
            }
        }

        public override IntervalSet Label
        {
            get
            {
                return IntervalSet.Of(label);
            }
        }

        public override bool Matches(int symbol, int minVocabSymbol, int maxVocabSymbol)
        {
            return label == symbol;
        }

        [NotNull]
        public override string ToString()
        {
            return label.ToString();
        }
    }
}
