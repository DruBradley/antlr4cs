// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

/*
* Copyright (c) 2012 The ANTLR Project. All rights reserved.
* Use of this file is governed by the BSD-3-Clause license that
* can be found in the LICENSE.txt file in the project root.
*/
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime
{
    /// <summary>
    /// A handy class for use with
    /// options {contextSuperClass=org.antlr.v4.runtime.RuleContextWithAltNum;}
    /// that provides a property for the outer alternative number
    /// matched for an internal parse tree node.
    /// </summary>
    public class RuleContextWithAltNum : ParserRuleContext
    {
        private int altNumber;

        public RuleContextWithAltNum()
        {
            altNumber = ATN.InvalidAltNumber;
        }

        public RuleContextWithAltNum(ParserRuleContext parent, int invokingStateNumber)
            : base(parent, invokingStateNumber)
        {
        }

        public override int OuterAlternative
        {
            get
            {
                return altNumber;
            }
            set
            {
                int altNum = value;
                this.altNumber = altNum;
            }
        }
    }
}
