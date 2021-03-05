/**********************************************************************
   Project           : MadLibs
   File name         : Builder.cs
   Author            : Rilegis
   Date created      : 8/10/2019
   Purpose           : The 'Builder' class contains the methods needed to
                       populate a story with user's inputs.
                       Builder.Run takes a JSON-formatted story object as
                       argument, then cycles through 'input types' as defined
                       on the story file (see 'types' array in the story file),
                       asking for the user input, and finally prints the story.

   Revision History  :
   Date        Author      Ref     Revision 
   22/12/2019  Rilegis     1       Changed file header.
**********************************************************************/

using System;

namespace MadLibs
{
    public static class Builder
    {
        private static string _baseStory;
        private static string _story;

        public static void Run(StoryFilesHandler selectedStoryJSONObj)
        {
            // Retrieve relevant data:
            foreach (string line in selectedStoryJSONObj.StoryLines) _baseStory = $"{_baseStory}\n{line}";

            // And define the arrays
            string[] words = new string[selectedStoryJSONObj.Types.Length];

            // Now asks for inputs
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write($"{selectedStoryJSONObj.Types[i]}: ");
                words[i] = Console.ReadLine().ToUpper();
                if (words[i] == "") // If value is empty make the user insert one
                {
                    Console.WriteLine($"{selectedStoryJSONObj.Types[i]} value cannot be left empty.");
                    i--;
                }
            }

            // Now print the story:
            _story = string.Format($"{_baseStory}", words);
            Console.WriteLine($"{_story}");
            _baseStory = "";
        }
    }
}
