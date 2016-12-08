# BoxField


Make the following changes to the BoxField game we started in class.

1.	Add a second list for the right side so that boxes fall to the right of the first column of boxes, (same y position). 

2.	Create a pattern. That is have the boxes generated to the left of the one before it for say 7 boxes, and then generate all boxes to the right of the previous box for 12 boxes, etc. 

3.	Add a colour value to the box class and generate a random colour for each box that drops. There are multiple ways to do this. 

One way is to create an array of type SolidBrush and fill it with different coloured brushes. When creating a new box generate a random number from 0 up to the number of brushes in the array. Send this value to the object constructor. For example:

Box b = new Box(100, 0, 1);

In the example above the 1 is the random colour value. Then when drawing in the paint method use the brushes array at the index indicated by the colour value in the object to select the desired brush color.
