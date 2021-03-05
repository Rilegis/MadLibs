/**********************************************************************
   Project           : MadLibs
   File name         : MadLibs.cs
   Author            : Rilegis
   Date created      : 17/6/2019
   Purpose           : Madlibs.Run visualizes a list of all the stories titles and
                       associates a number (0 - n-1) for it's execution, then asks
                       the user which one he/she would like to run, after that
                       Builder.Run will be executed for the selected story.

   Revision History  :
   Date        Author      Ref     Revision 
   22/12/2019  Rilegis     1       Changed file header.
**********************************************************************/

using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace MadLibs
{
    public static class MadLibs
    {
        private static string[] _storyFiles;
        private static dynamic _jsonFile;
        private static string _input;
        private static int _testParse;
        private static int _selectedStory;

        public static void Run()
        {
            Console.WriteLine("Welcome to MadLibs! Choose from one of the following stories:");

            // Get a list of story files from 'stories' directory
            _storyFiles = Directory.GetFiles(@"./stories/", "*.json", SearchOption.TopDirectoryOnly);

            // Create an index for story files
            for (int i = 0; i < _storyFiles.Length; i++)
            {
                _jsonFile = JsonConvert.DeserializeObject<StoryFilesHandler>(File.ReadAllText(_storyFiles[i]));
                _storyFiles[i] = _jsonFile.Title;
                Console.WriteLine($"{i}: {_storyFiles[i]}");
            }

            // Make the user select a story
            while (true)
            {
                Console.Write("Select a story: ");
                _input = Console.ReadLine();

                // Then check if _input has a valid value
                if (!_input.All(char.IsDigit)) // If _input does not contains only numbers
                    Console.WriteLine($"Please, insert a number between 0 and {_storyFiles.Length - 1}.");
                else if (int.TryParse(_input, out _testParse)) // If it's a number, then check for value
                {
                    if (_testParse > _storyFiles.Length - 1) Console.WriteLine($"Please, insert a number between 0 and {_storyFiles.Length - 1}.");
                    else if (_testParse < 0) Console.WriteLine($"Please, insert a number between 0 and {_storyFiles.Length - 1}.");
                    else // If everything is ok, then exit the loop
                    {
                        _selectedStory = _testParse;
                        Console.WriteLine($"You have selected the story: {_storyFiles[_selectedStory]}");
                        break;
                    }
                }
            }

            // At this point, start the story builder
            Console.Write("\n\n");
            _storyFiles = Directory.GetFiles(@"./stories/", "*.json", SearchOption.TopDirectoryOnly);
            _jsonFile = JsonConvert.DeserializeObject<StoryFilesHandler>(File.ReadAllText(_storyFiles[_selectedStory]));
            Builder.Run(_jsonFile);
        }
    }
}
