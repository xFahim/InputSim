   M S B A M L   `   `   `  ����C  ?InputSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InputSimInputSim  5          InputSim.HookSavePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:InputSim     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$ HookSavePage��5      .��5      � .+�5   
   �� $��Center=�6   $��Center=�62   .+�5      �� -   5        $��BackBtn��5      $
��Left=�6:   
������ 
������ $	��Top=�6�   .��5      ��  J� Opacity$	 0.6Q�6    �� Orientation$ 
Horizontal=�6+   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   $��20��6?   $��20��6J   6X   �� 5      $��Center=�6    $��5 0 0 0q�6;   	Back Home6W   5      5      �� 5      -   5        $��HdataListView��5      $	��858��6,   $	��240��68   $��0 10 0 0q�6E   ��6W   ��  �� View 5      �� 5       	 �� AllowsColumnReorder	 . 
 �� ColumnHeaderToolTip$
 	Input Set��5!      .P�5#      �� $��Index��5%       �� Width$ 68��6&    �� DisplayMemberBinding 5#   )   ��  �� Path$ 
InputIndex�5%   &   �� 5'      $��
Delay (ms)��5(      $ 95��6+    �� CellTemplate 5)      �� 5*   "   .R�5+   &   �� $��0q�6.   ��6B   �� $ Timespan� �� Mode$ TwoWay=�6p   5,   #   5.      �� 50      $	 124��52      $��Mouse Event��6#    50   )   �� $ MouseEventName�53      �� 55      $��	Mouse (x)��57      $ 90��6*    55   )   �� $ MousePointX�57   *   �� 59      $��	Mouse (y)��5;      $ 90��6*    59   )   �� $ MousePointY�5;   *   �� 5=      $��Key (Keyboard)��5?      $	 122��6/    5=   )   �� $ KeyName�5?   /   �� 5A      $��Keyboard Event��5C      $	 125��6/    5A   )   �� $ KeyboardEventName�5C   /   �� 5E      $��Repeat��5F      $ 74��6'    5G      �� 5H   "   .R�5I   &   �� $��0q�6.   ��6B   �� $ RepeatSingular�$ TwoWay=�6v   5J   #   5L      5N      5P      �� 5S      $
��Left=�6   $ 
Horizontal=�64   .+�5T      �� -   5        $��	RemoveBtn��5T   .   $��10 10 10 10q�6   $	��200��6W   .��6c   Remove from list6u   5V      �� 5X      $ 
Horizontal=�6   $
��Left=�62   $��10 20 10 10q�6M   .+�5Y      �� -   5        $��LoopBox��5Y      $	��120��6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Repeat (Default 0)��65   6k   �� 5Z      -   5        $��AssignKeyBtn��5Z      $��20 0 0 0q�6-   
������ 
������ .��5[      �� -   5         �Name$ AsignKeyHyperLink��5[       
�������.�6L   .�5\      �� $ 
Horizontal=�6%   .+�5]        -   5        $��AssignKeyIcon��5]   6   $ GestureTapButton=�6K   $��20��6c   $��20��6n   6|   �� 5^      -   5        $��AssignKeyText��5^   (   $��10 0 0 0q�6=   Assign a key6]   5_      5`      5a      �� 5c      $	 0.6Q�6   $��20 0 0 0q�6*   $��SemiBold"�6<   $��Center=�6R   ���	#DDFFFFFFAsigned Key:6�   �� 5d      -	   5        $��AsignKeyStatusTxt��5d      $��Center=�65   $��10 0 0 0q�6P   N/A6h   �� 5e      $��Center=�6   $��30 0 0 0q�67   $	 0.3Q�6I   KI(The sc_ prefix stands for "scan code". The last part holds the key name)6�   5f      �� 5h      $ 
Horizontal=�6   $��
10 5 10 10q�62   .+�5i      �� -
   5        $��TagBox��5i      $	��200��6(   $
��Left=�64   $ Tag for the InputSet��6P   6�   �� 5j      -   5        $��DescriptionBox��5j      $��20 0 0 0q�60   $	��400��6B   $
��Left=�6N   $ description (optional)��6j   6�   5k      �� 5l      -   5        $��SaveBtn��5l      $	��200��6:   $��10q�6F   $
��Left=�6R   .��6m   Save InputSet6|   5m      5n      5o      