   M S B A M L   `   `   `  ����J  FAWS_Wpf_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:AWS_Wpf_Project.UserControlsAWS_Wpf_Project.UserControls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      0    *AWS_Wpf_Project.UserControls.SearchControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:AWS_Wpf_Project.UserControls     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5
         BorderBackground �� Color  WatermarkTextForeground % !ButtonClearBorderBrushIsMouseOver & "ButtonClearBorderBrushIsMouseLeave # ButtonClearBorderBrushIsPressed  ControlBorderBrushIsFocused ! ControlBorderBrushIsUnfocused  BorderCornerRadius  BorderThickness 	 BorderPadding 
 WatermarkTextFontStyle  ButtonClearBackgroundImage �� ImageSource  ClearButtonStyle �� 
TargetType �� 	Resources  Key �� Triggers P� Property P� Value �� Property ! IsMouseOverButtonClearOpacity	 �� Value $  IsNotMouseOverButtonClearOpacity
 �� ScaleY �� ScaleX �� Angle �� 
TargetType �� Padding �� CornerRadius �� Triggers �� 
TargetName  WaterMarkTextBoxTemplate ��Name ��Name ��Name J� IsHitTestVisible ��Name � ToolTip��%�  &	        &	 !     &	 H     &	 g     &	 �     &	 �     &	 �     &	 �     &	     &		     &	
 4    &	 R    &	 �    7  7  7  7  7  7  &	 #    7  7 	 7   7  7 
 7  7  7  7  7  �� 5   
   $ #FFFFFF��63   �� 5   
   $ DarkSlateGray��6:   �� 5   
   $ Black��6D   �� 5   
   $ Transparent��6E   �� 5   
   $
 Gray��6B   �� 5   
   $
 Blue��6>   �� 5   
   $ #888888��6@   ��5   
   2��65   u�5   
   1q�6/   u�5   
   2q�6-   %�5   
   
Italic$�6<   �� 5!   
   $N Hpack://application:,,,/AWS_Wpf_Project;component/Resources/Editclear.png��68   �� 5$   
   " ��6)    5%      ��X�5&      !IsMouseOverButtonClearOpacity 1Q�6J   X�5'      $ IsNotMouseOverButtonClearOpacity 0.5Q�6O   5(       5)      P� 5*       �@J�IsMouseOver . . �5+      ��  �@J�Opacity8	   60   5,      P� 5-       �@J�IsMouseOver .  . �5.      ��  �@J�Opacity8	  60   5/      .�51      ��  �@�FocusVisualStyle	 61   Z� �� 52       � ��$	 25��6'   �� 53       � ��$	 23��6&   �� 54       � z�	 55      V� 56      .~�57      �� $
 -1Q�6)   $ -1Q�65   �� 58      �� 59      $
 -180Q�6*   T� 5:      5;      5=      �� 5>       �@J�RenderTransformOrigin$	 0.5,0.5&�66   �� 5?       � ��	 5@      �� 5A      " ��6&   .R�5B      �� $��border��6!   #��z��5C   !   # z��5D   !   #��z��5E   !   $ 5��5F   !   #��z��5G   !   ._�5H      �� $��Center=�6/   $��Center=�6L   5I       5J      P� 5K       �@J�IsMouseOver . . �5L   "   �� 8	   � ��6@   5M      P� 5N       �@J�IsMouseOver .  . �5O   "   �� 8	   � ��6@   5P      P� 5Q       � {� .  . �5R   "   ��  �@J�Opacity$
	 0.25Q�6<   �� 5S   "   8	   � ��6@   5T      P� 5U       � �� . . �5V   "   �� $ border��6)   8	   � ��6T   5W      5Y      5[      5\      �� 5`   
   " ��6   .R�5a      �� $ Border��6   8   8  8�� 8�� ._�5f      � .+�5g      �� $ PART_ContentHost��6#   $��0q�6=   �� 5i      $ WaterMarkText��6    $��5,0,0,0q�67   $y�Hidden=�6H    .  $��Center=�6u   8�� 8�� $��поиск ...��5l       �� 5n      $ ClearTextButton��6   -   5        $��18��5n   6   $��18��6B   $��0q�6M   $��0q�6Y   $��0q�6d   $��Right=�6x   $y�Visible=�5o      $ Очистить��5p      8�� 8�� 5t      5u      5v       5w      P� 5x       �@J�	IsFocused . . �5y      �� $ Border��6   8	   � ��6H   5z      P� 5{       �@J�	IsFocused .  . �5|      �� $ Border��6   8	 	  � ��6H   5}      P� 5       � ��$  ��6*   . �5�      �� $ WaterMarkText��63    � y�$	 Visible=�6N   �� 5�      $ ClearTextButton��63    � y�$	 Hidden=�6P   5�      5�      5�      .��5�      � .+�5�   
   �� -   5         ��Name$ 	txtSearch��5�      #��[ 6%   $��Center=�5�      ��5�      �� *ControlText+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5�      5�      