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
    /// <summary>
    /// This implementation of
    /// <see cref="IAntlrErrorStrategy"/>
    /// responds to syntax errors
    /// by immediately canceling the parse operation with a
    /// <see cref="ParseCanceledException"/>
    /// . The implementation ensures that the
    /// <see cref="ParserRuleContext.exception"/>
    /// field is set for all parse tree nodes
    /// that were not completed prior to encountering the error.
    /// <p>
    /// This error strategy is useful in the following scenarios.</p>
    /// <ul>
    /// <li><strong>Two-stage parsing:</strong> This error strategy allows the first
    /// stage of two-stage parsing to immediately terminate if an error is
    /// encountered, and immediately fall back to the second stage. In addition to
    /// avoiding wasted work by attempting to recover from errors here, the empty
    /// implementation of
    /// <see cref="Sync(Parser)"/>
    /// improves the performance of
    /// the first stage.</li>
    /// <li><strong>Silent validation:</strong> When syntax errors are not being
    /// reported or logged, and the parse result is simply ignored if errors occur,
    /// the
    /// <see cref="BailErrorStrategy"/>
    /// avoids wasting work on recovering from errors
    /// when the result will be ignored either way.</li>
    /// </ul>
    /// <p>
    /// <c>myparser.setErrorHandler(new BailErrorStrategy());</c>
    /// </p>
    /// </summary>
    /// <seealso cref="Parser.ErrorHandler(IAntlrErrorStrategy)"/>
    public class BailErrorStrategy : DefaultErrorStrategy
    {
        /// <summary>
        /// Instead of recovering from exception
        /// <paramref name="e"/>
        /// , re-throw it wrapped
        /// in a
        /// <see cref="ParseCanceledException"/>
        /// so it is not caught by the
        /// rule function catches.  Use
        /// <see cref="System.Exception.InnerException()"/>
        /// to get the
        /// original
        /// <see cref="RecognitionException"/>
        /// .
        /// </summary>
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            for (ParserRuleContext context = recognizer.Context; context != null; context = ((ParserRuleContext)context.Parent))
            {
                context.exception = e;
            }
            throw new ParseCanceledException(e);
        }

        /// <summary>
        /// Make sure we don't attempt to recover inline; if the parser
        /// successfully recovers, it won't throw an exception.
        /// </summary>
        /// <exception cref="Antlr4.Runtime.RecognitionException"/>
        public override IToken RecoverInline(Parser recognizer)
        {
            InputMismatchException e = new InputMismatchException(recognizer);
            for (ParserRuleContext context = recognizer.Context; context != null; context = ((ParserRuleContext)context.Parent))
            {
                context.exception = e;
            }
            throw new ParseCanceledException(e);
        }

        /// <summary>Make sure we don't attempt to recover from problems in subrules.</summary>
        public override void Sync(Parser recognizer)
        {
        }
    }
}
