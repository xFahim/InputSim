   M S B A M L   `   `   `  ����C  ?InputSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InputSimInputSim  5          InputSim.CustomSimulate   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:InputSim     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   .��5      � .+�5   
   �� .+�5      �� -   5        $��BackBtn��5      $
��Left=�6:   
������ 
������ $	��Top=�6�   .��5      ��  J� Opacity$	 0.6Q�6    �� Orientation$ 
Horizontal=�6+   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   $��20��6?   $��20��6J   6X   �� 5      $��Center=�6    $��5 0 0 0q�6;   	Back Home6W   5      5      � 5      $��	22 10 0 0q�6   .+�5      �� $��SemiBold"�6   $	 0.4Q�62   $��Bottom=�6@   Inputs to be performed :6u   5      �� 5       -   5        $��HdataListView��5       $	��200��6-   $��4q�6:   ��6E   �� *	AllInputs+ �� Mode$ TwoWay=� �� View 5"      �� 5#      	 �� AllowsColumnReorder	 . 
 �� ColumnHeaderToolTip$
 	Input Set��5$      .P�5&      �� $��Index��5(       �� Width$ 68��6&    �� DisplayMemberBinding 5&   )   ��  �� Path$ 
InputIndex�5(   &   �� 5*      $��
Input Type��5,      $	 100��6+    5*   )   �� $ HookTypeName�5,   +   �� 5.      $��
Delay (ms)��5/      $ 95��6+    �� CellTemplate 50      �� 51   "   .R�52   &   �� $��0q�6.   ��6B   �� $ Timespan�$ TwoWay=�6p   53   #   55      �� 57      $	 125��59      $��Mouse Event��6#    57   )   �� $ MouseEventName�5:      �� 5<      $��	Mouse (x)��5>      $ 90��6*    5<   )   �� $ MousePointX�5>   *   �� 5@      $��	Mouse (y)��5B      $ 90��6*    5@   )   �� $ MousePointY�5B   *   �� 5D      $��Key (Keyboard)��5F      $	 122��6/    5D   )   �� $ KeyName�5F   /   �� 5H      $��Keyboard Event��5J      $	 125��6/    5H   )   �� $ KeyboardEventName�5J   /   �� 5L      $��Repeat��5M      $ 74��6'    5N      �� 5O   "   .R�5P   &   �� $��0q�6.   ��6B   �� $ RepeatSingular�$ TwoWay=�6v   5Q   #   5S      5U      5W      � 5Y       � ColumnDefinitions 5Z      �� 5[      �� 5\      .+�5`      �� .+�5d      9� -   5        $��ManualExpander��5d      $	��450��65   $��Center=�6A   $��0q�6^    9� 
IsExpanded .  ��5e      �� 5f      $
��Left=�6)   $ 
Horizontal=�6D   .+�5g   "     $	 Add=�6:   �� 5h   "   $��5 0 0 0q�6,   $	 0.5Q�6=   $��SemiBold"�6K   Add Inputs Manually6v   5i      .��5k      �� $��0q�6%   .+�5m      �� $ 
Horizontal=�6)   $��10q�6B   .+�5n   "   	� -   5        $��MI_CheckBox��5n   .   .��6_   Mouse Input6l   	� 5o   "   -   5        $��KI_CheckBox��5o   .   $��10 0 0 0q�6_   .��6q   Keyboard Input6�   �� 5p   "   -   5        $��TspanBox��5p   *   $��10 0 0 0q�6:   $��Center=�6L   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Time Span��6g   $��80��6�   6�   5q      �� 5t      -   5        $��MouseInputBoxSetStack��5t   )   $ 
Horizontal=�6F   $��
10 0 10 10q�6_   .+�5u   "   �� -   5        $��MouseEventComboBox��5u   +   $ Mouse Event��6E   6t   �� 5v   "   -	   5        $
��XBox��5v   *   $��20 0 0 0q�66   $ 	Point (x)��6H   6u   �� 5w   "   -
   5        $
��YBox��5w   *   $��20 0 0 0q�66   $ 	Point (y)��6H   6u   �� 5x   "   -   5        $��ExtraDataBox��5x   *   $��20 0 0 0q�6>   $ 
Extra Data��6P   6~   5y      �� 5|      -   5        $��KeyboardInputBoxSetStack��5|   )   $ 
Horizontal=�6I   $��
10 0 10 10q�6b   .+�5}   "   �� -   5        $��KeyboardEventComboBox��5}   +   $ Keyboard Event��6H   6z   �� 5~   "   -   5        $��KeyboardBtn��5~   )   $��0 0 0 0q�6<   
������ 
������ .��5   &   �� -   5         �Name$ AsignKeyHyperLink��5   0   
�������.�6\   .�5�   *   �� $ 
Horizontal=�65   .+�5�   .     -   5        $��AssignKeyIcon��5�   F   $ GestureTapButton=�6[   $��20��6s   $��20��6~   6�   �� 5�   .   -   5        $��AssignKeyText��5�   8   $��10 0 0 0q�6M   
Select key6k   5�   +   5�   '   5�   #   �� 5�   "   -   5        $��KeyStatusTxt��5�   ,   $��Center=�6@   $	 0.7Q�6[   
Key: N/A6s   5�      �� 5�      -   5        $��AddManualBtn��5�   %   $��10 0 0 0q�69   $
��Left=�6K   $	��310��6f   .��6�   Add to list6�   5�      5�      9� 5�      -   5        $��SaveListExpander��5�      $	��450��67   $��Center=�6C   $��1��6`   $��5q�6�    .  ��5�      �� 5�      $
��Left=�6)   $ 
Horizontal=�6D   .+�5�   "     $	 Add=�6:   �� 5�   "   $��5 0 0 0q�6,   $	 0.5Q�6=   $��SemiBold"�6K   Add Inputs From Saved List6}   5�      .��5�      �� $��20q�6%   $��Center=�61   $��Center=�6N   .+�5�      �� -   5        $��TagBox��5�   &   $	��200��64   $ Enter tag of inputset��6@   6y   �� 5�      -   5        $��AddFromTagBtn��5�   %   $��15q�6V   .��6b   Add inputset to list6x   5�      5�      5�      �� 5�      $��1��6   $��Center=�6-   $��20q�6J   .+�5�      �� $ 
Horizontal=�6!   $��10q�6:   .+�5�      �� -   5        $��RemoveFromListBtn��5�   !   
������ $��0q�6s   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Clear=�6:   6I   �� 5�   "   $��5 0 0 0q�6,   Remove Selected Input6T   5�      5�      �� 5�      -   5        $��RemoveAllListBtn��5�   !   
������ $��0q�6q   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Trash=�6:   6I   �� 5�   "   $��5 0 0 0q�6,   
Remove All6I   5�      5�      5�      �� 5�      -   5        $��StartSimBtn��5�      $��5q�6J   .��6U   Start Simulation6g   5�      5�      5�      5�      5�      