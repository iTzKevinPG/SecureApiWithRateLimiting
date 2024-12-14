# 🚦 Rate Limiting Test Report 🚀

## 🛡️ Endpoint: `POST /api/auth/login`

### 📝 **Resumen**
Este reporte documenta las pruebas realizadas al endpoint de login para verificar la correcta implementación del **Rate Limiting** bajo la política `LowRate`.

---

### ✅ **Escenario 1: Solicitudes dentro del límite permitido**  
- **🔄 Iteraciones**: 10 en menos de 1 minuto.  
- **🔍 Resultado**:  
  - 🟢 Todas las solicitudes devolvieron `200 OK`.  
  - ⚡ El Rate Limiting no bloqueó ninguna solicitud dentro del límite.

---

### ❌ **Escenario 2: Exceso de solicitudes en el período de tiempo**  
- **🔄 Iteraciones**: 15 en menos de 1 minuto.  
- **🔍 Resultado**:  
  - 🟢 Las primeras 10 solicitudes devolvieron `200 OK`.  
  - 🔴 Las solicitudes adicionales devolvieron `429 Too Many Requests`.  
  - ✉️ Mensaje recibido:  
    ```
    You have exceeded the limit of requests. Please try again later.
    ```

---

### 🕒 **Escenario 3: Reinicio del contador después de 1 minuto**
- **🔄 Iteraciones**: 20 (10 solicitudes distribuidas en 1 minuto + 10 adicionales).
- **🔍 Resultado**:
  - 🟢 Todas las solicitudes dentro del límite inicial devolvieron `200 OK`.
  - 🕒 El contador se reinició correctamente después de 1 minuto.
  - 🟢 Las siguientes 10 solicitudes también devolvieron `200 OK`.

---

### 🌐 **Escenario 4: Solicitudes desde múltiples clientes**  
- **🔄 Iteraciones**: 10 solicitudes desde 2 clientes diferentes.  
- **🔍 Resultado**:  
  - 🟢 Cada cliente respetó su límite independiente de 10 solicitudes por minuto.  
  - 🔒 El sistema no aplicó el límite de manera global.

---

## 💡 **Conclusiones**
- ✅ El **Rate Limiting** se comporta correctamente según las políticas definidas.  
- 🚀 El endpoint está protegido contra abusos como ataques de fuerza bruta.  
- 🛡️ Recomendación futura: Integrar monitoreo de solicitudes bloqueadas para auditorías.

---

¡🎉 **Pruebas completadas con éxito!** 🎉
