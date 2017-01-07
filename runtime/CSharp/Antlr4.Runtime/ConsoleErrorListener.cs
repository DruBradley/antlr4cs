// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

/*
* Copyright (c) 2012 The ANTLR Project. All rights reserved.
* Use of this file is governed by the BSD-3-Clause license that
* can be found in the LICENSE.txt file in the project root.
*/
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime
{
    /// <author>Sam Harwell</author>
    public class ConsoleErrorListener : IAntlrErrorListener<object>
    {
        /// <summary>
        /// Provides a default instance of
        /// <see cref="ConsoleErrorListener"/>
        /// .
        /// </summary>
        public static readonly ConsoleErrorListener Instance = new ConsoleErrorListener();

        /// <summary>
        /// <inheritDoc/>
        /// <p>
        /// This implementation prints messages to
        /// <see cref="System.Console.Error"/>
        /// containing the
        /// values of
        /// <paramref name="line"/>
        /// ,
        /// <paramref name="charPositionInLine"/>
        /// , and
        /// <paramref name="msg"/>
        /// using
        /// the following format.</p>
        /// <pre>
        /// line <em>line</em>:<em>charPositionInLine</em> <em>msg</em>
        /// </pre>
        /// </summary>
        public virtual void SyntaxError<T>(Recognizer<T, object> recognizer, T offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            System.Console.Error.WriteLine("line " + line + ":" + charPositionInLine + " " + msg);
        }
    }
}
