﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notes.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessage() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Notes.Application.Resources.ErrorMessage", typeof(ErrorMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Внутренняя ошибка сервера.
        /// </summary>
        internal static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Заметка не найдена.
        /// </summary>
        internal static string NoteNotFound {
            get {
                return ResourceManager.GetString("NoteNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Заметки не найдены.
        /// </summary>
        internal static string NotesNotFound {
            get {
                return ResourceManager.GetString("NotesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации заметки при создании.
        /// </summary>
        internal static string NotValidCreateNoteDTO {
            get {
                return ResourceManager.GetString("NotValidCreateNoteDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации напоминания при создании.
        /// </summary>
        internal static string NotValidCreateReminderDTO {
            get {
                return ResourceManager.GetString("NotValidCreateReminderDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации тэга при создании.
        /// </summary>
        internal static string NotValidCreateTagDTO {
            get {
                return ResourceManager.GetString("NotValidCreateTagDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации заметки при обновлении.
        /// </summary>
        internal static string NotValidUpdateNoteDTO {
            get {
                return ResourceManager.GetString("NotValidUpdateNoteDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации напоминания при обновлении.
        /// </summary>
        internal static string NotValidUpdateReminderDTO {
            get {
                return ResourceManager.GetString("NotValidUpdateReminderDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка валидации тэга при обновлении.
        /// </summary>
        internal static string NotValidUpdateTagDTO {
            get {
                return ResourceManager.GetString("NotValidUpdateTagDTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Напоминание не найдено.
        /// </summary>
        internal static string ReminderNotFound {
            get {
                return ResourceManager.GetString("ReminderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Напоминания не найдены.
        /// </summary>
        internal static string RemindersNotFound {
            get {
                return ResourceManager.GetString("RemindersNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Тэг не найден.
        /// </summary>
        internal static string TagNotFound {
            get {
                return ResourceManager.GetString("TagNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Тэги не найдены.
        /// </summary>
        internal static string TagsNotFound {
            get {
                return ResourceManager.GetString("TagsNotFound", resourceCulture);
            }
        }
    }
}
