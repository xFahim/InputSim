   M S B A M L   `   `   `  ����C  ?InputSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InputSimInputSim  5   	       InputSim.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:InputSim     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $	��628��69   $	��998��6F    � 
ResizeMode$ NoResize=�6R    � WindowStartupLocation$ CenterOwner=�6h    � WindowStyle$
 None=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � .+�5      �� $��10q�6   $��0��6$   $��28(�61   $��Center=�6@   $��Segoe UI Light)�6]   
InputSim6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��2q�6N   .+�5      �� -   5        $��AboutBtn��5      
�������
������ 
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AboutVariant=�6.   6D   5       �� 5!      -   5        $��MinBtn��5!      
�������
������ 
������ .��5"        $ WindowMinimize=�6.   6F   5#      �� 5$      -   5        $��ExitBtn��5$      
�������
������ 
������ .��5%        $ Power=�6.   6=   5&      5'      5(       � 5*   
   -   5        $��MyBaseFrame��5*      $��1��6   	  � NavigationUIVisibility$	 Hidden=�60   6R   �� 5,   
   $��2��6   $��10q�6"   $��Center=�6.   $ 
Horizontal=�6K   .+�5-      �� 
 J� Opacity$	
 0.3Q�6   $��0 0 0 0q�6&   V .0.0.1 Beta5.      50      51      52      