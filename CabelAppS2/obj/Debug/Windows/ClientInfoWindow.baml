   M S B A M L   `   `   `  ����E  ACabelAppS2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CabelAppS2.WindowsCabelAppS2.Windows  5   	   )    #CabelAppS2.Windows.ClientInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CabelAppS2.Windows     5   	     � Title$  ClientInfoWindow��5   	    � WindowStartupLocation$ CenterScreen=�6"   $	��450��6G   $	��800��6W   $	��450��6f   $	��800��6s   .��5	      � -   5         �Name$ MainGrid��5	       � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� ��6   �� *Number+�� 5   
   $��1��6-   ��6   �� *	GetName+6-   �� 5   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   $��2��6K   .+�5      �� $��
0, 0 10, 0q�65   ��6   �� *GetPassport+65   �� 5      ��6   �� *GetPassportInfo+5      �� 5   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   .+�5      �� $��0, 0, 10, 0q�65   ��6   �� *GetContract+65   �� 5       ��6   �� *GetContractDateType+5!      �� 5"   
   $��4��63   ��6   �� *GetContactEnd+63   �� 5#   
   $��5��6-   ��6   �� *	GetBill+6-   �� 5$   
   $��6��60   ��6   �� *
GetAddress+60   �� 5%   
   $��7��61   ��6   �� *GetServices+61   �� 5&   
   $��8��62   ��6   �� *GetEquipment+62   �� 5'   
   $��9��6-   ��6   �� *	GetRent+6-   �� 5(   
   $��10��60   ��6   �� *
GetSupport+60   5)      5*      