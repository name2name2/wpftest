   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfApplication1.ConverterWpfApplication1.Converter  5      ,    &WpfApplication1.Views.OrdersEditorView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	converter'clr-namespace:WpfApplication1.Converter     5      $
��Auto��5   7   $
��Auto��6D     � 	Resources  5	         ErrorTemplate �� Padding �� CornerRadius.   (WpfApplication1.Converter.ErrorConverter  errorConverter-   'WpfApplication1.Converter.DateConverter  dateConverter?   9WpfApplication1.Converter.StringToNullableNumberConverter # stringToNullableNumberConverter  TextBoxInError �� 
TargetType-  'System.Windows.Input.KeyboardNavigation �� Property �� Value �� 
TargetType ��Name  WindowBackgroundBrush  SolidBorderBrush ��Name  SimpleScrollViewer	 �� Triggers
 P� Property P� Value �� RelativeSource �� Path �� 	Converter��%�  &	        &	 t     &	 �     &	 �     &	 �     7  �� 5
   
   .R�5      �� 
���  ��$��1q�6'   $ 2q�6;   $ 2��6G   ._�5      �� 5      5        5   
   6#     5   
   6"     5   
   64   �� 5   
   " ��6'   .�5      ��  �@ TabNavigation$
 None=�6A   �� 5       �@�FocusVisualStyle
 x:Null61   �� 5       � ��$ 0,5,0,5q�6'   �� 5       �@J�	AllowDrop . 6*   �� 5       � ��$
 Left=�64   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ Border��6%   #���  65   #���  6j   $��1q�6�   $ 2q�6�   $ 2��6�   ._�5   "   �� $ PART_ContentHost��6:   $��0q�6/   #���  6T   #��z��6�   6�   5      5      	 5       P� 5!      
 �@=�HasError . . �5"   -   ��  6G   ��  �� *Self+$ (Validation.Errors)�8    �@�ToolTip5#      5%      5'      5(      5*      5+      