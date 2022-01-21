# powerPlanners

To add the Start screen without commpatibility issues, downlaod only the StartScreenImport.unity package file.

When in your unity project, follow these steps:

1. Assuming you are on the game Scene, right click and find the import package box.
2. Locate the file and now you on the right side there should be a import unity package window. Just click import to add everything.
3. You should now see StartScreen import in your assests after saving. 
4. Import TMP essentials, otherwise the text on the screen will not show up.

5. To connect the start screen to the game, Go to File->Build Settings->Add open Scenes
6. Drag StartScene above the GameScene and make sure StartScene has a 0 on the right. And the GameScene has a 1.

Now when you run it, clicking on Start will will take you to your game Screen.

I did this becasue I was issues uploading files where there scenes being transferred.
