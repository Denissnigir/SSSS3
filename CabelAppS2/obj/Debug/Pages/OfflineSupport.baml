   M S B A M L   `   `   `  ����E  ACabelAppS2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CabelAppS2.PagesCabelAppS2.Pages  5      %    CabelAppS2.Pages.OfflineSupport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CabelAppS2.Pages     5        N� Title$  OfflineSupport��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.4* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��0.2* �6    �� 5      .+�5      � -   5         �Name$ UserGrid��5       5      �� 5      �� 5      �� 5      $
��0.5* �6'   .+�5      �� $��14(�64   ��6   �� *Number+64   �� 5      $��14(�6C   $��1��6Q   $
��Wrap=�6a    �� TextAlignment$ Center=�6u   ��6   �� *ServiceVariation.Name+6u   �� 5       -   5        $��2��5       $��10q�6)   $	��CSV��65   6C   5!      � 5#      $��1��6   .+�5$      �� -   5         ��Name$ 	Timesheet��5$       � 	Resources 5%       �� 
TargetType �� Property	 �� Value��%W   '��       �� 5&      " ��6    .�5'      ��  � ��$	 Stretch=�6K   5(      5)      ��5*      �� 5+      .R�5,      �  5-   "   �� 5.   &   �� 5/   &   .+�51   "   �� 
 �� Orientation$
 
Horizontal=�6-   .+�52   &   �� $��14(�6[   ��60   �� *	StartDate+ �� StringFormat$ t��6[   �� 53   &   $��-��60   $��
5, 0, 5, 0q�69   $��14(�6M   �� 54   &   $��14(�6Y   ��60   �� *	EndDate+$ t��6Y   55   #   �� 56   "   $��1��6[   $��14(�6k   $
��Wrap=�6y   $ Center=�6�   $	��200��6�   ��6,   �� *Request.ServiceVariation.Name+6�   57      58      5:      5;      5<      � 5>   
   $��1��6    5?      �� 5@      $
��0.2* �6    �� 5A      .+�5D      �� $��Инженеры��6   �� 5F      -   5        $ EmployeeList��5F   #   $��1��6   ��5G      �� 5H      .R�5I      � ��6   �� *
GetColor+.+�5J      �� $��14(�6A   $
��Wrap=�6O   $	��150��6c   $ Center=�6o   ��6(   �� *	GetName+6o   5K      5L      5N      5O      5P      5Q      