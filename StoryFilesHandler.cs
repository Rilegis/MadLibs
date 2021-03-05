/**********************************************************************
   Project           : MadLibs
   File name         : StoryFilesHandler.cs
   Author            : Rilegis
   Date created      : 18/6/2019
   Purpose           : The class 'StoryFilesHandler' contains the definition for the JSON story files.
                       Title: The story title.
                       StoryLines: String array containing every line from the story.
                       Types: String array containing every blank-spot input type.

   Revision History  :
   Date        Author      Ref     Revision 
   22/12/2019  Rilegis     1       Changed file header.
**********************************************************************/

namespace MadLibs
{
    public class StoryFilesHandler
    {
        public string Title { get; set; }
        public string[] StoryLines { get; set; }
        public string[] Types { get; set; }
    }
}
