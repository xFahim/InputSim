   M S B A M L   `   `   `  ����C  ?InputSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InputSimInputSim  5          InputSim.Recordpage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:InputSim     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$ 
Recordpage��5      .��5      � .+�5   
   �� -   5        $��BackBtn��5      $
��Left=�66   
������ 
������ $	��Top=�6�   .��5      ��  J� Opacity$	 0.6Q�6    �� Orientation$ 
Horizontal=�6'   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6*   $��20��6;   $��20��6F   6T   �� 5      $��Center=�6   $��5 0 0 0q�67   Back6N   5      5      �� 5   
   $��Center=�6   $��Center=�62   .+�5      � $��
0 10 10 10q�6   .+�5      �� $ 
Horizontal=�6   $
��Left=�66   .+�5      �� -   5        $��TagSearchBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Using Tag��62   $	��200��6d   6r   �� 5      -   5        $��	SearchBtn��5      $��10 0 0 0q�6F   .��6X   Search6`   5       5!      �� 5$      -   5        $��
RecordList��5$      $	��768��6)   $	��240��65   $��0 10 0 0q�6B   ��6T   �� 	 �� View	 5&      �� 5'      
 �� AllowsColumnReorder
 .  �� ColumnHeaderToolTip$ 	Input Set��5(      .P�5*      �� $��InputSet Tag��5,       �� Width$	 150��6-    �� DisplayMemberBinding 5*   )   ��  �� Path$	 Tag�5,   -   �� 5.      $	 150��50      $��Assigned key��6#    5.   )   �� $ AsignedKeyName�51      �� 53      $��Last Modified��55      $	 300��6.    53   )   �� $ DateText�55   .   57      59      �� 5=      $
��Left=�6   $ 
Horizontal=�64   .+�5>      �� -   5        $��
DetailsBtn��5>      $��10 10 10 10q�6D   $	��200��6Z   .��6f   View / Edit InputSet6|   �� 5?      -   5        $��	DeleteBtn��5?      $��10 10 10 10q�6B   $	��200��6X   .��6d   Delete InputSet6u   5A      5B      5C      5D      