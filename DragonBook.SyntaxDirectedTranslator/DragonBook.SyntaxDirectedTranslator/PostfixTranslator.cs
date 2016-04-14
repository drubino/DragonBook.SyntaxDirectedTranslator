using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBook.SyntaxDirectedTranslator
{
    public class PostfixTranslator
    {
        private string input;
        private int index;
        private StringBuilder builder;
        private char? Lookahead
        {
            get
            {
                return this.input.Length <= index ? 
                    (char?)null : 
                    this.input[index];
            }
        }

        public string Translate(string input)
        {
            this.input = input;
            this.index = 0;
            this.builder = new StringBuilder();
            TranslateExpression();

            return this.builder.ToString();
        }

        private void TranslateExpression()
        {
            this.TranslateTerm();
            while (true)
            {
                if (this.Lookahead == '+')
                {
                    Match('+');
                    TranslateTerm();
                    Write('+');
                }
                else if (this.Lookahead == '-')
                {
                    Match('-');
                    TranslateTerm();
                    Write('-');
                }
                else
                {
                    return;
                }
            }
        }

        private void TranslateTerm()
        {
            if (this.Lookahead.HasValue && !char.IsDigit(this.Lookahead.Value))
                throw new Exception($"'{this.Lookahead}' is not a digit.");
            Write(this.Lookahead);
            Match(this.Lookahead);
        }

        private void Match(char? character)
        {
            if (this.Lookahead != character)
                throw new Exception($"Could not match { character }");
            UpdateLookahead();
        }

        private void Write(char? character)
        {
            this.builder.Append(character);
        }

        private void Write(string str)
        {
            this.builder.Append(str);
        }

        private void UpdateLookahead()
        {
            this.index = this.index + 1;
        }
    }
}
