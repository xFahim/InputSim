   M S B A M L   `   `   `  ����C  ?InputSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InputSimInputSim  5          InputSim.Home   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:InputSim     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$
 Home��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��Center=�62   $��0��6M   $��0 20 0 0q�6]   .+�5      �� $��Assets/hook (1).png��6   $��44��61   $��44��6<   6J   �� 5      $��Center=�6   $��10q�65   $��22(�6A   Hook6V   �� 5      $��Center=�6   $
��Wrap=�65    J� Opacity$	 0.4Q�6I   $	��320��6W   geStart keeping track of all the keyboard and mouse inputs and asign them to a key to simulate later on6�   �� 5      $��5 20 5 5q�6   $
��Bold"�6*   $��12(�6<   $	 0.5Q�6J   Device Specific6i   �� 5       -   5        $��KeyInpCheckBox��5       {�. $��5 2 5 5q�6>    d� 	IsChecked$
 TrueY�6O   .��6`   Keyboard Inputs6q   �� 5!      -   5        $��MouseInpCheckBox��5!      {�. $��5 2 5 5q�6@   $
 TrueY�6Q   .��6b   Mouse Inputs6p   9� 5#      ��5$      �� 5%      $
��Left=�6!    �� Orientation$ 
Horizontal=�6<   .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Mouse=�62   �� 5'      $��5 0 0 0q�6$   $	 0.5Q�65   $��SemiBold"�6C   Advance Mouse Config6o   5(      ��5*      �� 5+      $��5q�6!   .+�5,      �� $	 0.5Q�6$   $
��Wrap=�62   $	��300��6F   20Choose which events to track during a mouse hook6�   � 5-       5.      �� 5/   "   �� 50   "   
 � RowDefinitions
 52      �� 53   "   �� 54   "   �� 55   "   �� 56   "   �� 57   "   �� 58   "   �� 59   "   .+�5<      �� -   5        $��LeftDownCheck��5<   '   $
 TrueY�6<   $��0��6M   $��0��6Z   $��0 5 0 0q�6j   .��6{   Left Button Down6�   �� 5=      -   5        $��RightDownCheck��5=   '   $
 TrueY�6=   $��0��6N   $��1��6[   $��0 5 0 0q�6k   .��6|   Right Button Down6�   �� 5>      -   5        $��LeftUpCheck��5>   '   $
 TrueY�6:   $��1��6K   $��0��6X   $��0 2 0 0q�6i   .��6z   Left Button Up6�   �� 5?      -   5        $��RightUpCheck��5?   '   $
 TrueY�6;   $��1��6L   $��1��6Y   $��0 2 0 0q�6j   .��6{   Right Button Up6�   �� 5G      -   5        $��
WheelCheck��5G   '   $��3��69   $��0��6F   {�. $��0 2 0 0q�6h   .��6y   Mouse Wheel6�   �� 5H      -   5        $��MovementCheck��5H   '   $��3��6<   $��1��6I   {�. $��0 2 0 0q�6�   .��6�   Mouse Movement6�   �� 5J      -	   5        $��
MidUpCheck��5J   '   $��4��69   $��0��6F   $��0 2 0 0q�6W   .��6h   Mid Button Up6w   �� 5K      -
   5        $��MidDownCheck��5K   '   $��4��6;   $��1��6H   $��0 2 0 0q�6Y   .��6j   Mid Button Down6{   �� 5N      -   5        $��LeftClickCheck��5N   '   $
 TrueY�6=   $��5��6�   $��0��6�   $��0 2 0 0q�6�   .��6�   
Left Click6�   �� 5O      -   5        $��RightClickCheck��5O   '   $
 TrueY�6>   $��5��6�   $��1��6�   $��0 2 0 0q�6�   .��6�   Right Click6�   �� 5Q      $��0 20 0 0q�6(   $��6��6:   $��Center=�6G   $	 0.5Q�6d   $��2��6r   �� 5R   "   -   5         �Name$ MouseConfigAboutBtn��5R   ,   
�������.�6|   .�5S   &   �� $ 
Horizontal=�61   .+�5T   *     $	 About=�6B   6Q   �� 5U   *   $��2 0 0 0q�64   $��SemiBold"�6E   &$Learn the conditions on mouse config6�   5V   '   5W   #   5X      5Y      5Z      5\      �� 5_      -   5        $��HookStartBtn��5_      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6D   $��5 15 5 5q�6u   $	��200��6�   .��6�   
Start Hook6�   5a      �� 5c   
   $��Center=�6   $��Center=�62   $��1��6M   $��0 0 0 0q�6]   .+�5d      �� $��Assets/simulator.png��6   $��56��62   $��56��6=   6K   �� 5e      $��Center=�6   $��5q�65   $��22(�6@   
Simulate6Y   �� 5f      $��Center=�6   $
��Wrap=�65   $	 0.4Q�6I   $	��320��6W   NLStart to simulate previously saved inputs by pressing the corresponding keys6�   	� 5g      -   5        $��SimUsingKey��5g      $
 TrueY�6-   $��0 20 0 0q�6>   .��5h      �� $	 0.6Q�6   Use asigned key to perform6F   5i      	� 5j      -   5        $��	ManualSim��5j      $��0 5 0 0q�6,   .��5k      �� $	 0.6Q�6   perform manually6<   5l      �� 5m      -   5        $��SimulateStartBtn��5m      $��5 15 5 5q�6L   $	��200��6^   .��6j   Simulate Input6z   �� 5p      $
 0.95Q�6   $��Assets/list (1).png��6#   $��0 30 0 0q�6A   $��45��6T   $��45��6_   6m   �� 5q      $��Center=�6   $��5q�65   $��22(�6@   	Records6X   �� 5r      $��Center=�6   $
��Wrap=�65   $	 0.4Q�6I   $	��320��6W   QOView, edit or modify the records/data of inputset which being previously saved.6�   �� 5s      -   5        $��
OpenRecBtn��5s      $��5 15 5 5q�6@   $	��200��6R   .��6^   Open Records6l   5v      5w      5x      