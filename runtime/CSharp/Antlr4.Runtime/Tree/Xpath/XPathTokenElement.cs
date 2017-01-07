// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

/*
* Copyright (c) 2012 The ANTLR Project. All rights reserved.
* Use of this file is governed by the BSD-3-Clause license that
* can be found in the LICENSE.txt file in the project root.
*/
using System.Collections.Generic;
using Antlr4.Runtime.Sharpen;
using Antlr4.Runtime.Tree;

namespace Antlr4.Runtime.Tree.Xpath
{
    public class XPathTokenElement : XPathElement
    {
        protected internal int tokenType;

        public XPathTokenElement(string tokenName, int tokenType)
            : base(tokenName)
        {
            this.tokenType = tokenType;
        }

        public override ICollection<IParseTree> Evaluate(IParseTree t)
        {
            // return all children of t that match nodeName
            IList<IParseTree> nodes = new List<IParseTree>();
            foreach (ITree c in Trees.GetChildren(t))
            {
                if (c is ITerminalNode)
                {
                    ITerminalNode tnode = (ITerminalNode)c;
                    if ((tnode.Symbol.Type == tokenType && !invert) || (tnode.Symbol.Type != tokenType && invert))
                    {
                        nodes.Add(tnode);
                    }
                }
            }
            return nodes;
        }
    }
}
