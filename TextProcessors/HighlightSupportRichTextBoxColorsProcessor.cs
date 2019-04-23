using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BorsenoTextEditor.Extensions;

namespace BorsenoTextEditor.TextProcessors
{
    class HighlightSupportRichTextBoxColorsProcessor
    {
        public HighlightSupportRichTextBox HighlightSupportRichTextBox { get; }

        public Color DefaultColor { get; }

        public HighlightSupportRichTextBoxColorsProcessor(HighlightSupportRichTextBox richTextBox, Color defaultColor)
        {
            HighlightSupportRichTextBox = richTextBox;
            DefaultColor = defaultColor;
        }

        public void ResetTextBoxColors()
        {
            HighlightSupportRichTextBox.BeginUpdate();

            HighlightSupportRichTextBox.ForeColor = DefaultColor;

            int selectionStart = HighlightSupportRichTextBox.SelectionStart;
            int selectionLength = HighlightSupportRichTextBox.SelectionLength;

            HighlightSupportRichTextBox.SelectAll();
            HighlightSupportRichTextBox.SelectionColor = DefaultColor;
            HighlightSupportRichTextBox.DeselectAll();

            HighlightSupportRichTextBox.SelectionStart = selectionStart;
            HighlightSupportRichTextBox.SelectionLength = selectionLength;

            HighlightSupportRichTextBox.EndUpdate();
        }

        public void HighlightSyntax(Regex regex, Color color)
        {
            var text = HighlightSupportRichTextBox.Text;

            var matches =
                regex.Matches(text).Cast<Match>().ToArray();

            ResetTextBoxColors();

            HighlightSupportRichTextBox.BeginUpdate();

            int lastIndex = HighlightSupportRichTextBox.SelectionStart;
            int lastLength = HighlightSupportRichTextBox.SelectionLength;

            HighlightSupportRichTextBox.SelectAll();

            if (matches.Length > 0)
            {
                int start = 0;
                int end = matches.Length - 1;

                SelectMatchesFromArr(matches, start, end, color);
            }

            HighlightSupportRichTextBox.Select(lastIndex, lastLength);
            HighlightSupportRichTextBox.SelectionColor = DefaultColor;

            HighlightSupportRichTextBox.EndUpdate();
        }

        private void SelectMatchesFromArr(Match[] matches, int startIndex, int endIndex, Color color)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                int selectionStart = HighlightSupportRichTextBox.SelectionStart;

                HighlightSupportRichTextBox.Select(matches[i].Index, matches[i].Length);
                HighlightSupportRichTextBox.SelectionColor = color;

                HighlightSupportRichTextBox.DeselectAll();
                HighlightSupportRichTextBox.SelectionStart = selectionStart;
                HighlightSupportRichTextBox.SelectionLength = 0;
            }
        }
    }
}
